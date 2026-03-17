import { BrowserRouter, Link, Route, Routes } from "react-router-dom";
import ImportStatus from "./pages/ImportStatus";
import MapColumns from "./pages/MapColumns";
import NewImport from "./pages/NewImport";
import ValidatePreview from "./pages/ValidatePreview";

function App() {
  return (
    <BrowserRouter>
      <header style={{ padding: "1rem", borderBottom: "1px solid #ccc" }}>
        <nav>
          <Link to="/" style={{ fontWeight: "bold", fontSize: "1.25rem" }}>
            Import Wizard
          </Link>
        </nav>
      </header>

      <Routes>
        {/* Home → start a new import */}
        <Route path="/" element={<NewImport />} />

        {/* Import wizard steps */}
        <Route path="/import/:id/map-columns" element={<MapColumns />} />
        <Route path="/import/:id/validate" element={<ValidatePreview />} />
        <Route path="/import/:id/status" element={<ImportStatus />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
