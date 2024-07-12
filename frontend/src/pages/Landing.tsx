import heroImage1 from "../assets/hero-1.jpg";
import heroImage2 from "../assets/hero-2.jpg";

export function Landing() {
    return (
        <>
            <div className="grid grid-cols-1 items-center">
                <div className="navbar bg-base-100 shadow-md m-1 col-auto">
                    <div className="flex-1">
                        <a className="btn btn-ghost text-xl">TodoList</a>
                    </div>
                    <div className="flex-none">
                        <ul className="menu menu-horizontal px-1">
                            <li>
                                <a>Login</a>
                            </li>
                            <li>
                                <a>Register</a>
                            </li>
                        </ul>
                    </div>
                </div>
                <div className="hero min-h-screen bg-white col-auto">
                    <div className="hero-content flex-col lg:flex-row-reverse">
                        <img
                            src={heroImage1}
                            className=" rounded-lg shadow-2xl"
                        />
                        <div>
                            <h1 className="text-5xl font-bold">
                                Streamline your workflow
                            </h1>
                            <p className="py-6">
                                Our todo app helps you stay organized and
                                focused, with features like task prioritization,
                                due dates, and reminders.
                            </p>
                            <button className="btn btn-primary">
                                Get Started
                            </button>
                        </div>
                    </div>
                </div>
                <div className="hero bg-white min-h-screen">
                    <div className="hero-content flex-col lg:flex-row">
                        <img
                            src={heroImage2}
                            className=" rounded-lg shadow-2xl"
                        />
                        <div>
                            <h1 className="text-5xl font-bold">
                                Simplify your life with Todo
                            </h1>
                            <p className="py-6">
                                Stay organized and on top of your tasks with our
                                intuitive todo list app.
                            </p>
                            <button className="btn btn-primary">
                                Get Started
                            </button>
                        </div>
                    </div>
                </div>
                <div className="hero bg-base-200 min-h-screen ">
                    <div className="hero-content flex-col card w-full shadow-lg lg:flex-row-reverse">
                        <div className="text-center ">
                            <h1 className="text-5xl font-bold">
                                Register now!
                            </h1>
                        </div>
                        <div className="card bg-base-100 w-full max-w-sm shrink-0 shadow-sm">
                            <form className="card-body">
                                <div className="form-control">
                                    <label className="label">
                                        <span className="label-text">
                                            User Name
                                        </span>
                                    </label>
                                    <input
                                        type="text"
                                        placeholder="user name"
                                        className="input input-bordered"
                                        required
                                    />
                                </div>
                                <div className="form-control">
                                    <label className="label">
                                        <span className="label-text">
                                            Email
                                        </span>
                                    </label>
                                    <input
                                        type="email"
                                        placeholder="email"
                                        className="input input-bordered"
                                        required
                                    />
                                </div>
                                <div className="form-control">
                                    <label className="label">
                                        <span className="label-text">
                                            Password
                                        </span>
                                    </label>
                                    <input
                                        type="password"
                                        placeholder="password"
                                        className="input input-bordered"
                                        required
                                    />
                                    <label className="label">
                                        <a
                                            href="#"
                                            className="label-text-alt link link-hover"
                                        ></a>
                                    </label>
                                </div>
                                <div className="gap-2 form-control mt-6 ">
                                    <button className="btn btn-primary">
                                        Register
                                    </button>
                                </div>
                            </form>
                        </div>
                        <div className="text-center ">
                            <h1 className="text-5xl font-bold">Login</h1>
                        </div>
                        <div className="card bg-base-100 w-full max-w-sm shrink-0 shadow-sm">
                            <form className="card-body">
                                <div className="form-control">
                                    <label className="label">
                                        <span className="label-text">
                                            User Name
                                        </span>
                                    </label>
                                    <input
                                        type="text"
                                        placeholder="user name"
                                        className="input input-bordered"
                                        required
                                    />
                                </div>

                                <div className="form-control">
                                    <label className="label">
                                        <span className="label-text">
                                            Password
                                        </span>
                                    </label>
                                    <input
                                        type="password"
                                        placeholder="password"
                                        className="input input-bordered"
                                        required
                                    />
                                    <label className="label">
                                        <a
                                            href="#"
                                            className="label-text-alt link link-hover"
                                        ></a>
                                    </label>
                                </div>
                                <div className="gap-2 form-control mt-6 ">
                                    <button className="btn btn-primary">
                                        Login
                                    </button>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
                <footer className="footer footer-center bg-base-300 text-base-content p-4">
                    <aside>
                        <p>
                            Copyright © ${new Date().getFullYear()} - All right
                            reserved by ACME Industries Ltd
                        </p>
                    </aside>
                </footer>
            </div>
        </>
    );
}
