import { Link, useLocation } from "react-router-dom";
import React from "react";

export function Header() {
    const location = useLocation();

    const getTitle = (pathname: string) => {
        switch (pathname) {
            case "/":
                return "Home";
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

    const detailsRef = React.useRef<HTMLDetailsElement | null>(null);
    const handleClick = () => {
        if (detailsRef.current && detailsRef.current.open) {
            detailsRef.current.removeAttribute("open");
        }
    };

    return (
        <div className="navbar bg-base-100 z-10">
            <div className="flex-1">
                <ul className="menu menu-horizontal px-1">
                    <li>
                        <details ref={detailsRef}>
                            <summary>Menu</summary>
                            <ul className="bg-base-100 rounded-t-none p-2">
                                <li>
                                    <Link to="/dashboard" onClick={handleClick}>
                                        Dashboard
                                    </Link>
                                </li>
                                <li>
                                    <Link to="/task" onClick={handleClick}>
                                        Task
                                    </Link>
                                </li>
                                <li>
                                    <Link to="/" onClick={handleClick}>
                                        Home
                                    </Link>
                                </li>
                                <li>
                                    <Link to="/user" onClick={handleClick}>
                                        User
                                    </Link>
                                </li>
                            </ul>
                        </details>
                    </li>
                </ul>
            </div>
            <div className="flex-auto">
                <a className="btn btn-ghost text-xl">{title}</a>
            </div>
        </div>
    );
}
