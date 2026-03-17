import { Link, useParams } from "react-router-dom";

/**
 * ValidatePreview page
 *
 * TODO: Implement validation preview:
 *  1. POST /api/import-runs/{id}/validate to trigger server-side validation.
 *  2. Display a paginated preview of rows with any validation errors highlighted.
 *  3. Allow the user to fix errors or proceed to /import/:id/status.
 */
export default function ValidatePreview() {
  const { id } = useParams<{ id: string }>();

  return (
    <main style={{ padding: "2rem" }}>
      <h1>Validate Preview</h1>
      <p>
        <em>Placeholder — validation table coming soon.</em>
      </p>
      <p>Import run ID: {id}</p>
      <nav>
        <ul>
          <li>
            <Link to={`/import/${id}/status`}>Start Import</Link>
          </li>
        </ul>
      </nav>
    </main>
  );
}
