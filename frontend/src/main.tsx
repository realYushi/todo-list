import React, { useEffect } from "react";
import ReactDOM from "react-dom/client";
import "./main.css";
import { Router } from "./Router";

function App() {
  return (
    <React.StrictMode>
      <>
        <Router />
      </>
    </React.StrictMode>
  );
}

ReactDOM.createRoot(document.getElementById("root")!).render(<App />);
