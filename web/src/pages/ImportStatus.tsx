import { useParams } from "react-router-dom";

/**
 * ImportStatus page
 *
 * TODO: Implement import progress monitoring:
 *  1. Poll GET /api/import-runs/{id}/status every few seconds (or switch to SSE).
 *  2. Show a progress bar: processedRows / totalRows.
 *  3. Display a live error count with a link to the errors list.
 *  4. Show a completion / failure banner when the run finishes.
 */
export default function ImportStatus() {
  const { id } = useParams<{ id: string }>();

  return (
    <main style={{ padding: "2rem" }}>
      <h1>Import Status</h1>
      <p>
        <em>Placeholder — progress polling coming soon.</em>
      </p>
      <p>Import run ID: {id}</p>
      <p>Status: Pending</p>
      <p>Progress: 0 / 0 rows</p>
    </main>
  );
}
