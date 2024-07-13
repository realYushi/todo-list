export function UserInfo() {
    return (
        <>
            <div className="card bg-base-100  shadow-xl m-4">
                <div className="card-body">
                    <h2 className="card-title">User Information</h2>
                    <p>You can change your information here </p>
                </div>

                <label className="form-control w-full m-4">
                    <div className="label">
                        <span className="label-text">Email</span>
                    </div>
                    <input
                        type="email"
                        placeholder="Email"
                        className="input input-bordered w-full max-w-xs"
                    />
                </label>
                <label className="form-control w-full m-4">
                    <div className="label">
                        <span className="label-text">User Name</span>
                    </div>
                    <input
                        type="text"
                        placeholder="User Name"
                        className="input input-bordered w-full max-w-xs"
                    />
                </label>
                <button className="btn btn-neutral m-4">Confirm</button>
            </div>
        </>
    );
}
