import { Link } from "react-router-dom";

/**
 * NewImport page
 *
 * TODO: Implement import creation flow:
 *  1. User selects or drags a CSV/Excel file.
 *  2. POST /api/import-runs to create an ImportRun.
 *  3. POST /api/import-runs/{id}/upload to upload the file.
 *  4. Navigate to /import/:id/map-columns.
 */
export default function NewImport() {
  return (
    <main style={{ padding: "2rem" }}>
      <h1>New Import</h1>
      <p>
        <em>Placeholder — upload form coming soon.</em>
      </p>
      <p>
        Steps: select file → map columns → validate preview → run import →
        monitor progress.
      </p>
      <nav>
        <ul>
          <li>
            <Link to="/import/demo/map-columns">Map Columns (demo)</Link>
          </li>
        </ul>
      </nav>
    </main>
  );
}
