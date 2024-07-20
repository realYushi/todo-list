import { useRef, useEffect, useState } from "react";
import { Link, useLocation } from "react-router-dom";
import { themeChange } from "theme-change";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faMoon, faSun } from "@fortawesome/free-solid-svg-icons";

export function Header() {
  const [isDark, setIsDark] = useState<boolean>(false);

  useEffect(() => {
    const currentTheme = localStorage.getItem("theme");
    setIsDark(currentTheme === "dracula");

    themeChange(false);
  }, []);

  const toggleTheme = () => {
    const newTheme = isDark ? "light" : "dracula";
    setIsDark(!isDark);
    localStorage.setItem("theme", newTheme);
    document.documentElement.setAttribute("data-theme", newTheme);
  };

  const location = useLocation();

  const navRef = useRef<HTMLDetailsElement | null>(null);
  const removeAttribute = () => {
    if (navRef.current) {
      navRef.current.removeAttribute("open");
    }
  };

  const getTitle = (pathname: string) => {
    switch (pathname) {
      case "/dashboard":
        return "Dashboard";
      case "/task":
        return "Task";
      case "/user":
        return "User";
      default:
        return "ToDo List App";
    }
  };

  const title = getTitle(location.pathname);

  return (
    <div className="navbar bg-base-100 px-4">
      <div className="navbar-start">
        <details className="dropdown lg:hidden" ref={navRef}>
          <summary tabIndex={0} className="btn btn-ghost">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              className="h-5 w-5"
              fill="none"
              viewBox="0 0 24 24"
              stroke="currentColor"
            >
              <path
                strokeLinecap="round"
                strokeLinejoin="round"
                strokeWidth="2"
                d="M4 6h16M4 12h8m-8 6h16"
              />
            </svg>
          </summary>
          <ul
            tabIndex={0}
            className="menu dropdown-content menu-sm z-[1] mt-3 w-52 rounded-box bg-base-100 p-2 shadow"
          >
            <li onClick={removeAttribute}>
              <Link to="/dashboard">Dashboard</Link>
            </li>
            <li onClick={removeAttribute}>
              <Link to="/task">Task</Link>
            </li>
            <li onClick={removeAttribute}>
              <Link to="/user">User</Link>
            </li>
          </ul>
        </details>
        <ul className="menu menu-horizontal hidden gap-10 px-1 lg:flex">
          <li>
            <Link to="/dashboard">Dashboard</Link>
          </li>
          <li>
            <Link to="/task">Task</Link>
          </li>
          <li>
            <Link to="/user">User</Link>
          </li>
        </ul>
      </div>
      <div className="navbar-center">
        <a className="btn btn-ghost text-xl">{title}</a>
      </div>
      <div className="navbar-end">
        <button className="btn btn-sm" onClick={toggleTheme}>
          <FontAwesomeIcon icon={isDark ? faSun : faMoon} />
        </button>
      </div>
    </div>
  );
}
