export function UserInfo() {
    return (
        <>
            <div className="card bg-base-100  shadow-xl m-4">
                <div className="card-body">
                    <h2 className="card-title">User Information</h2>
                    <p>You can change your information here </p>
                </div>

                <label className="form-control w-full max-w-xs">
                    <div className="label">
                        <span className="label-text">What is your name?</span>
                        <span className="label-text-alt">Top Right label</span>
                    </div>
                    <input
                        type="text"
                        placeholder="Type here"
                        className="input input-bordered w-full max-w-xs"
                    />
                    <div className="label">
                        <span className="label-text-alt">
                            Bottom Left label
                        </span>
                        <span className="label-text-alt">
                            Bottom Right label
                        </span>
                    </div>
                </label>
            </div>
        </>
    );
}
