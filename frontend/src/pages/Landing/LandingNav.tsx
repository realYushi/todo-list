export function Navbar() {
  return (
    <div className="bg-base-50 navbar col-auto m-1 shadow-md">
      <div className="flex-1">
        <a className="btn btn-ghost text-xl">TodoList</a>
      </div>
      <div className="flex-none">
        <ul className="menu menu-horizontal px-1">
          <li>
            <a href="#loginForm">Login</a>
          </li>
          <li>
            <a href="#registerForm">Register</a>
          </li>
        </ul>
      </div>
    </div>
  )
}
