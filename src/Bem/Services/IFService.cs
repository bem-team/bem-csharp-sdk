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
    /// <para>## Quick reference</para>
    ///
    /// <para>| Op | `path` | Other fields | What it does |
    /// |----|--------|-------------|--------------| | `ls` | — | `filter`, `limit`,
    /// `cursor` | List parsed documents | | `grep` | referenceID *(optional)* |
    /// `pattern`, `scope`, `countOnly` | Search across documents | | `cat` |
    /// referenceID | `range`, `select` | Read a document's parsed content | | `head` |
    /// referenceID | `n` | First N sections (default 10) | | `stat` | referenceID *or*
    /// entityID | — | Metadata only | | `find` | — | `filter`, `limit`, `cursor` | List
    /// canonical entities | | `open` | entityID | — | Entity detail + all mentions | |
    /// `xref` | entityID | `limit`, `cursor` | Sections across docs mentioning an
    /// entity |</para>
    ///
    /// <para>**`path`** is the positional identifier. For doc ops (`cat`, `head`,
    /// `stat`), pass a `referenceID` from `ls`. For entity ops (`open`, `xref`), pass
    /// an `entityID` from `find`. `grep` optionally takes a `path` to scope search to
    /// one document.</para>
    ///
    /// <para>## Examples</para>
    ///
    /// <para>**List documents:** `{"op": "ls"}`</para>
    ///
    /// <para>**Search one document:** `{"op": "grep", "path": "my-doc-001", "pattern":
    /// "holiday", "scope": "sections"}`</para>
    ///
    /// <para>**Read one page:** `{"op": "cat", "path": "my-doc-001", "range": {"page":
    /// 7}}`</para>
    ///
    /// <para>**Read a page range:** `{"op": "cat", "path": "my-doc-001", "range":
    /// {"pageRange": [5, 10]}}`</para>
    ///
    /// <para>**Project section labels and pages only:** `{"op": "cat", "path":
    /// "my-doc-001", "select": ["sections.label", "sections.page", "sections.type"]}`</para>
    ///
    /// <para>**Preview first 5 sections:** `{"op": "head", "path": "my-doc-001", "n":
    /// 5}`</para>
    ///
    /// <para>**Document metadata:** `{"op": "stat", "path": "my-doc-001"}`</para>
    ///
    /// <para>**List entities:** `{"op": "find"}`</para>
    ///
    /// <para>**Entity detail + mentions:** `{"op": "open", "path": "ent_abc123"}`</para>
    ///
    /// <para>**Cross-document sections for an entity:** `{"op": "xref", "path":
    /// "ent_abc123"}`</para>
    ///
    /// <para>## Key details</para>
    ///
    /// <para>`range` is an **object** with optional keys: `page` (integer), `pageRange`
    /// (two-element array `[from, to]`), `sectionTypes` (array of strings like
    /// `["table", "heading"]`).</para>
    ///
    /// <para>`select` is an **array of strings** — dotted paths like
    /// `["sections.label", "sections.page"]`.</para>
    ///
    /// <para>`scope` (grep) is one of `"sections"`, `"entities"`, `"relationships"`, or
    /// `"all"` (default).</para>
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
