export function Navbar() {
    return (
        <div className="navbar bg-base-50 shadow-md m-1 col-auto">
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
    );
}

interface HeroSectionProps {
    imageSrc: string;
    title: string;
    description: string;
    buttonText: string;
    buttonLink: string;
}

export function HeroSection({
    imageSrc,
    title,
    description,
    buttonText,
    buttonLink,
}: HeroSectionProps) {
    return (
        <div className="hero min-h-screen bg-white col-auto">
            <div className="hero-content flex-col lg:flex-row-reverse lg:max-w-2xl">
                <img src={imageSrc} className="rounded-lg shadow-2xl" />
                <div>
                    <h1 className="text-5xl font-bold">{title}</h1>
                    <p className="py-6">{description}</p>
                    <button className="btn btn-primary">
                        <a href={buttonLink}>{buttonText}</a>
                    </button>
                </div>
            </div>
        </div>
    );
}

export function FormComponent() {
    return (
        <div className="hero bg-base-200 min-h-screen">
            <div className="hero-content flex-col card w-full shadow-lg lg:flex-row">
                <RegisterForm />
                <LoginForm />
            </div>
        </div>
    );
}
const RegisterForm = () => {
    return (
        <div className="lg:flex-col lg:w-1/2 w-10/12">
            <div className="text-center">
                <h1 className="text-5xl font-bold m-4">Register</h1>
            </div>
            <div className="card bg-base-100 w-full shadow-sm">
                <form className="card-body">
                    <div className="form-control">
                        <label className="label" id="registerForm">
                            <span className="label-text">User Name</span>
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
                            <span className="label-text">Email</span>
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
                            <span className="label-text">Password</span>
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
                    <div className="gap-2 form-control mt-6">
                        <button className="btn btn-primary">Register</button>
                    </div>
                </form>
            </div>
        </div>
    );
};
const LoginForm = () => {
    return (
        <div className="lg:flex-col lg:w-1/2 w-10/12">
            <div className="text-center">
                <h1 className="text-5xl font-bold m-4">Login</h1>
            </div>
            <div className="card bg-base-100 w-full shadow-sm">
                <form className="card-body">
                    <div className="form-control">
                        <label className="label" id="loginForm">
                            <span className="label-text">User Name</span>
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
                            <span className="label-text">Password</span>
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
                    <div className="gap-2 form-control mt-6">
                        <button className="btn btn-primary">Login</button>
                    </div>
                </form>
            </div>
        </div>
    );
};
export function Footer() {
    return (
        <footer className="footer footer-center bg-base-300 text-base-content p-4">
            <aside>
                <p>
                    Copyright © {new Date().getFullYear()} - All rights reserved
                    by ACME Industries Ltd
                </p>
            </aside>
        </footer>
    );
}
