import { Link, useParams } from "react-router-dom";

/**
 * MapColumns page
 *
 * TODO: Implement column mapping:
 *  1. Fetch the detected CSV headers from the API.
 *  2. Render a mapping UI: source column → target field.
 *  3. Save the mapping and navigate to /import/:id/validate.
 */
export default function MapColumns() {
  const { id } = useParams<{ id: string }>();

  return (
    <main style={{ padding: "2rem" }}>
      <h1>Map Columns</h1>
      <p>
        <em>Placeholder — column mapping UI coming soon.</em>
      </p>
      <p>Import run ID: {id}</p>
      <nav>
        <ul>
          <li>
            <Link to={`/import/${id}/validate`}>Validate Preview</Link>
          </li>
        </ul>
      </nav>
    </main>
  );
}
