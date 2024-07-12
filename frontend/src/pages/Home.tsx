export function Home() {
    return (
        <>
            <div className="hero min-h-screen bg-white">
                <div className="hero-content flex-col lg:flex-row-reverse">
                    <img
                        src="https://img.daisyui.com/images/stock/photo-1635805737707-575885ab0820.jpg"
                        className="max-w-sm rounded-lg shadow-2xl"
                    />
                    <div>
                        <h1 className="text-5xl font-bold">Box Office News!</h1>
                        <p className="py-6">
                            Provident cupiditate voluptatem et in. Quaerat
                            fugiat ut assumenda excepturi exercitationem quasi.
                            In deleniti eaque aut repudiandae et a id nisi.
                        </p>
                        <button className="btn btn-primary">Get Started</button>
                    </div>
                </div>
            </div>
            <div className="hero bg-white min-h-screen">
                <div className="hero-content flex-col lg:flex-row">
                    <img
                        src="https://img.daisyui.com/images/stock/photo-1635805737707-575885ab0820.jpg"
                        className="max-w-sm rounded-lg shadow-2xl"
                    />
                    <div>
                        <h1 className="text-5xl font-bold">Box Office News!</h1>
                        <p className="py-6">
                            Provident cupiditate voluptatem et in. Quaerat
                            fugiat ut assumenda excepturi exercitationem quasi.
                            In deleniti eaque aut repudiandae et a id nisi.
                        </p>
                        <button className="btn btn-primary">Get Started</button>
                    </div>
                </div>
            </div>
            <div className="hero bg-base-200 min-h-screen ">
                <div className="hero-content flex-col card w-full shadow-lg lg:flex-row-reverse">
                    <div className="text-center ">
                        <h1 className="text-5xl font-bold">Register now!</h1>
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
                            <div className="gap-2 form-control mt-6 ">
                                <button className="btn btn-primary">
                                    Login
                                </button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </>
    );
}
