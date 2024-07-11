import { Link } from "react-router-dom";
import React from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faBars, faBell, faUser } from "@fortawesome/free-solid-svg-icons";

export function Header() {
    const [isMenuOpen, setIsMenuOpen] = React.useState(false);
    const toggleMenu = () => setIsMenuOpen(!isMenuOpen);
    const handleNavigation = () => {
        setIsMenuOpen(false);
    };
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

    return (
        <div>
            <header className="grid grid-cols-8 items-center shadow-md py-4 gap-1 bg-gray-100">
                <button
                    className="col-span-1 text-gray-700 hover:text-gray-900"
                    onClick={toggleMenu}
                >
                    <FontAwesomeIcon icon={faBars} size="lg" />
                </button>
                <h1 className="col-span-5 text-center text-xl font-bold text-gray-800">
                    {title}
                </h1>
                <div className="col-span-2 grid grid-cols-2">
                    <button className="text-gray-700 hover:text-gray-900">
                        <FontAwesomeIcon icon={faBell} size="lg" />
                    </button>
                    <button className="text-gray-700 hover:text-gray-900">
                        <FontAwesomeIcon icon={faUser} size="lg" />
                    </button>
                </div>
            </header>
            {isMenuOpen && (
                <nav className="container mx-auto px-4 py-2 bg-white shadow-md">
                    <ul className="grid grid-cols-1 gap-2">
                        {["Home", "User", "Dashboard", "Task"].map((item) => (
                            <li key={item}>
                                <Link
                                    to={
                                        item === "Home"
                                            ? "/"
                                            : `/${item.toLowerCase()}`
                                    }
                                    onClick={handleNavigation}
                                    className="block py-2 px-4 text-gray-700 hover:bg-gray-100 rounded transition-colors"
                                >
                                    {item}
                                </Link>
                            </li>
                        ))}
                    </ul>
                </nav>
            )}
        </div>
    );
}
