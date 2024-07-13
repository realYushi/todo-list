export function Setting() {
  return (
    <>
      <div className="card col-span-2 m-4 bg-base-100 shadow-xl">
        <div className="card-body">
          <h2 className="card-title">Setting</h2>
          <p>You can change your Setting here </p>
        </div>

        <label className="form-control m-4 w-full">
          <div className="label grid grid-cols-4 items-center">
            <span className="label-text col-span-2 text-center">Theme</span>
            <label className="col-span-2 flex cursor-pointer gap-2">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="20"
                height="20"
                viewBox="0 0 24 24"
                fill="none"
                stroke="currentColor"
                strokeWidth="2"
                strokeLinecap="round"
                strokeLinejoin="round"
              >
                <circle cx="12" cy="12" r="5" />
                <path d="M12 1v2M12 21v2M4.2 4.2l1.4 1.4M18.4 18.4l1.4 1.4M1 12h2M21 12h2M4.2 19.8l1.4-1.4M18.4 5.6l1.4-1.4" />
              </svg>
              <input
                type="checkbox"
                value="synthwave"
                className="theme-controller toggle"
              />
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="20"
                height="20"
                viewBox="0 0 24 24"
                fill="none"
                stroke="currentColor"
                strokeWidth="2"
                strokeLinecap="round"
                strokeLinejoin="round"
              >
                <path d="M21 12.79A9 9 0 1 1 11.21 3 7 7 0 0 0 21 12.79z"></path>
              </svg>
            </label>
          </div>
        </label>
      </div>
    </>
  );
}
