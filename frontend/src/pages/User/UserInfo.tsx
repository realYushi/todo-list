import IUser from "@modelsUserInterface";
import { useState } from "react";
import { RootState } from "@storestore";
import { useDispatch, useSelector } from "react-redux";
import { updateUser } from "@storetask/userSlice";

export function UserInfo() {
  const dispatch = useDispatch();
  const userId = useSelector((state: RootState) => state.user.userId);
  const [userName, setUserName] = useState<string>("");
  const [email, setEmail] = useState<string>("");
  const [currentPassword, setCurrentPassword] = useState<string>("");
  const [newPassword, setNewPassword] = useState<string>("");
  const [confirmPassword, setConfirmPassword] = useState<string>("");

  const handleUserInfo = () => {
    const newUser: IUser = {
      email: email,
      username: userName,
      password: newPassword === confirmPassword ? newPassword : "",
      userId: userId,
    };

    if (
      newUser.password === "" ||
      newUser.email === "" ||
      newUser.username === ""
    ) {
      alert("Please fill in all fields or check if the passwords match");
      return;
    } else {
      dispatch(updateUser(newUser));
      alert("User information updated successfully");
    }
  };

  return (
    <div className="flex justify-center">
      <div className="lg:w-3/4">
        <div className="card m-4 bg-base-100 p-1 shadow-xl">
          <div className="card-body">
            <h2 className="card-title">User Information</h2>
            <p>You can change your Email and Password here</p>

            <label className="form-control mt-4 w-full">
              <div className="label">
                <span className="label-text">User Name</span>
              </div>
              <input
                type="text"
                value={userName}
                placeholder="User Name"
                onChange={(e) => setUserName(e.target.value)}
                className="input input-bordered w-full max-w-xs"
              />
            </label>

            <label className="form-control mt-4 w-full">
              <div className="label">
                <span className="label-text">Current Password</span>
              </div>
              <input
                type="password"
                value={currentPassword}
                placeholder="Current Password"
                onChange={(e) => setCurrentPassword(e.target.value)}
                className="input input-bordered w-full max-w-xs"
              />
            </label>
            <div className="divider"></div>
            <label className="form-control w-full">
              <div className="label">
                <span className="label-text">New Email</span>
              </div>
              <input
                type="email"
                value={email}
                placeholder="New Email"
                onChange={(e) => setEmail(e.target.value)}
                className="input input-bordered w-full max-w-xs"
              />
            </label>
            <label className="form-control mt-4 w-full">
              <div className="label">
                <span className="label-text">New Password</span>
              </div>
              <input
                type="password"
                value={newPassword}
                placeholder="New Password"
                onChange={(e) => setNewPassword(e.target.value)}
                className="input input-bordered w-full max-w-xs"
              />
            </label>

            <label className="form-control mt-4 w-full">
              <div className="label">
                <span className="label-text">Confirm Password</span>
              </div>
              <input
                type="password"
                value={confirmPassword}
                placeholder="Confirm Password"
                onChange={(e) => setConfirmPassword(e.target.value)}
                className="input input-bordered w-full max-w-xs"
              />
            </label>

            <button className="btn btn-neutral mt-6" onClick={handleUserInfo}>
              Confirm Changes
            </button>
          </div>
        </div>
      </div>
    </div>
  );
}
