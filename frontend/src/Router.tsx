import { Index } from "./components/Layout/Body"
import { Dashboard } from "./pages/Dashboard"
import { Landing } from "./pages/Landing"
import { Task } from "./pages/Task"
import { User } from "./pages/User"
import { BrowserRouter, Route, Routes } from "react-router-dom"
export function Router() {
  return (
    <BrowserRouter>
      <Routes>
        <Route index element={<Landing />} />
        <Route path="/" element={<Index />}>
          <Route path="dashboard" element={<Dashboard />} />
          <Route path="task" element={<Task />} />
          <Route path="user" element={<User />} />
        </Route>
      </Routes>
    </BrowserRouter>
  )
}
