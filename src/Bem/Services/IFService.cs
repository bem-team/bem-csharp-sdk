using System;
using System.Threading;
using System.Threading.Tasks;
using Bem.Core;
using Bem.Models.Fs;

namespace Bem.Services;

/// <summary>
/// Unix-shell-style nav over parsed documents and the cross-doc memory store.
///
/// <para>`POST /v3/fs` is a single op-driven endpoint designed for LLM agents and
/// programmatic consumers that want to walk a corpus the way they'd walk a filesystem.</para>
///
/// <para>## Doc-level ops (every parsed document)</para>
///
/// <para>- `ls` — list parsed documents with rich per-doc metadata. - `cat` — read
/// one doc's parse JSON, sliced (`range`) or projected (`select`). - `head` — first
/// N sections of one doc. - `grep` — substring or regex search; `scope`, `path`,
/// `countOnly` available. - `stat` — metadata only (page/section/entity counts, timestamps).</para>
///
/// <para>## Memory-level ops (require `linkAcrossDocuments: true` on the parse function)</para>
///
/// <para>- `find` — list canonical entities across the corpus. - `open` — entity
/// + mentions. - `xref` — for one entity, sections across docs that mention it (with content).</para>
///
/// <para>Memory ops return an empty list with a `hint` when no docs in this environment
/// have been memory-linked.</para>
///
/// <para>## Pagination</para>
///
/// <para>List ops paginate by cursor — pass the previous response's `nextCursor`
/// back as `cursor`; `hasMore: false` signals the last page. Same idiom as `/v3/calls`
/// and `/v3/outputs`.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IFService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// **Navigate parsed documents and the cross-doc memory store via Unix-shell
    /// verbs.**
    ///
    /// <para>`POST /v3/fs` is a single op-driven endpoint that lets an LLM agent (or
    /// any programmatic client) walk a corpus the way it would walk a filesystem — `ls`
    /// to list, `cat` to read, `grep` to search, `head` for a quick peek, `stat` for
    /// metadata, and `find` / `open` / `xref` for the cross-doc entity memory layer.</para>
    ///
    /// <para>The body always carries an `op` field; other fields apply per op. The
    /// response envelope is uniform: `{op, data, hasMore?, nextCursor?, count?,
    /// hint?}`.</para>
    ///
    /// <para>## Doc-level ops (work on every parsed document)</para>
    ///
    /// <para>- `ls`: list parsed documents with `pageCount`, `sectionCount`,
    /// `entityCount`, and a short `previewEntities` array. - `cat`: read one doc's full
    /// parse JSON, optionally sliced by `range` (page / pageRange / sectionTypes) or
    /// projected by `select` (dotted paths like `["sections.label", "sections.page"]`).
    /// - `head`: first N sections of one doc. - `grep`: substring or regex search
    /// across recent parse outputs. `scope` restricts to `sections` / `entities` /
    /// `relationships`. `path` scopes to one doc. `countOnly: true` returns only the
    /// hit count. - `stat`: metadata only — page/section/entity counts, timestamps.</para>
    ///
    /// <para>## Memory-level ops (require `linkAcrossDocuments: true` on the parse
    /// function)</para>
    ///
    /// <para>- `find`: list canonical entities, filterable by `type`, `search`,
    /// `since`. Returns an empty list with a `hint` when no docs have been
    /// memory-linked. - `open`: fetch one entity plus its mentions across docs. -
    /// `xref`: for one entity, return the actual sections (with content) across docs
    /// that mention it. The "where exactly is X discussed" loop in one round trip.</para>
    ///
    /// <para>## Pagination</para>
    ///
    /// <para>List ops (`ls`, `find`) paginate by cursor: pass the last item's
    /// `nextCursor` from a previous response to fetch the next page; `hasMore: false`
    /// signals the last page. Same idiom as `/v3/calls` and `/v3/outputs`.</para>
    /// </summary>
    Task<FNavigateResponse> Navigate(
        FNavigateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IFService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/fs</c>, but is otherwise the
    /// same as <see cref="IFService.Navigate(FNavigateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FNavigateResponse>> Navigate(
        FNavigateParams parameters,
        CancellationToken cancellationToken = default
    );
}
