import React from "react"
import ReactDOM from "react-dom/client"
import "./main.css"
import { Router } from "./Router"
import { Provider } from "react-redux"
import { store } from "@store/store"
function App() {
  return (
    <React.StrictMode>
      <Provider store={store}>
        <Router />
      </Provider>
    </React.StrictMode>
  )
}
ReactDOM.createRoot(document.getElementById("root")!).render(<App />)
