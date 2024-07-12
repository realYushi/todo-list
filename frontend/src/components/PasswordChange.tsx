export function PasswordChange() {
    return (
        <>
            <div className="card bg-base-100  shadow-xl m-4">
                <div className="card-body">
                    <h2 className="card-title">Password</h2>
                    <p>You can change your Password here </p>
                </div>

                <label className="form-control w-full m-4">
                    <div className="label">
                        <span className="label-text">Password</span>
                    </div>
                    <input
                        type="password"
                        placeholder="Password"
                        className="input input-bordered w-full max-w-xs"
                    />
                </label>
                <label className="form-control w-full m-4">
                    <div className="label">
                        <span className="label-text">Confirm Password</span>
                    </div>
                    <input
                        type="password"
                        placeholder="Confirm Password"
                        className="input input-bordered w-full max-w-xs"
                    />
                </label>
                <button className="btn btn-neutral m-4">Confirm</button>
            </div>
        </>
    );
}
