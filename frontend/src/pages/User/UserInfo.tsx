import IUser from "@models/UserInterface"
import {
  useLoginMutation,
  useLogoutMutation,
  useUpdateUserMutation,
} from "@service/userEndpoint"
import { useState } from "react"
import { jwtDecode } from "jwt-decode"
import { useNavigate } from "react-router-dom" // Import useNavigate

export function UserInfo() {
  const [userName, setUserName] = useState<string>("")
  const [currentEmail, setCurrentEmail] = useState<string>("")
  const [newEmail, setNewEmail] = useState<string>("")
  const [currentPassword, setCurrentPassword] = useState<string>("")
  const [newPassword, setNewPassword] = useState<string>("")
  const [confirmPassword, setConfirmPassword] = useState<string>("")
  const [userId, setUserId] = useState<string>("")
  const [login] = useLoginMutation()
  const [logout] = useLogoutMutation()
  const [updateUser] = useUpdateUserMutation()

  const navigate = useNavigate() // Add this line

  const handleUserInfo = async () => {
    try {
      // First, attempt to login with current credentials
      const loginResult = await login({
        username: userName,
        email: currentEmail,
        password: currentPassword,
      }).unwrap()

      if (loginResult.token) {
        // Decode the token to get user information
        const decodedToken: any = jwtDecode(loginResult.token)
        setUserId(decodedToken.sub) // Assuming the token contains userId

        const newUser: IUser = {
          email: newEmail || currentEmail,
          username: userName,
          password: newPassword === confirmPassword ? newPassword : "",
          userId: decodedToken.sub,
        }

        if (!newUser.password || !newUser.email || !newUser.username) {
          alert("Please fill in all fields or check if the passwords match")
          return
        }

        // Update user information
        await updateUser(newUser).unwrap()
        alert("User information updated successfully")
      }
    } catch (error) {
      console.error("Error updating user info:", error)
      alert("Failed to update user information. Please check your credentials.")
    }
  }

  const handleLogout = async () => {
    try {
      logout()
      alert("Logged out successfully")
      navigate("/") // Redirect to login page after logout
      navigate(0)
    } catch (error) {
      console.error("Error logging out:", error)
      alert("Failed to logout. Please try again.")
    }
  }

  return (
    <div className="flex justify-center items-center min-h-screen">
      <div className="w-full max-w-md">
        <div className="card bg-base-100 shadow-xl">
          <div className="card-body">
            <h2 className="card-title text-center">User Information</h2>
            <p className="">You can change your Email and Password here</p>

            <form className="mt-4 space-y-4">
              <label className="form-control w-full">
                <div className="label">
                  <span className="label-text">User Name</span>
                </div>
                <input
                  required
                  type="text"
                  value={userName}
                  placeholder="User Name"
                  onChange={e => setUserName(e.target.value)}
                  className="input input-bordered w-full"
                />
              </label>

              <label className="form-control w-full">
                <div className="label">
                  <span className="label-text">Current Password</span>
                </div>
                <input
                  required
                  type="password"
                  value={currentPassword}
                  placeholder="Current Password"
                  onChange={e => setCurrentPassword(e.target.value)}
                  className="input input-bordered w-full"
                />
              </label>

              <label className="form-control w-full">
                <div className="label">
                  <span className="label-text">Current Email</span>
                </div>
                <input
                  required
                  type="email"
                  value={currentEmail}
                  placeholder="Current Email"
                  onChange={e => setCurrentEmail(e.target.value)}
                  className="input input-bordered w-full"
                />
              </label>
              <div className="divider"></div>
              <label className="form-control w-full">
                <div className="label">
                  <span className="label-text">New Email</span>
                </div>
                <input
                  required
                  type="email"
                  value={newEmail}
                  placeholder="New Email"
                  onChange={e => setNewEmail(e.target.value)}
                  className="input input-bordered w-full"
                />
              </label>
              <label className="form-control w-full">
                <div className="label">
                  <span className="label-text">New Password</span>
                </div>
                <input
                  required
                  type="password"
                  value={newPassword}
                  placeholder="New Password"
                  onChange={e => setNewPassword(e.target.value)}
                  className="input input-bordered w-full"
                />
              </label>

              <label className="form-control w-full">
                <div className="label">
                  <span className="label-text">Confirm Password</span>
                </div>
                <input
                  required
                  type="password"
                  value={confirmPassword}
                  placeholder="Confirm Password"
                  onChange={e => setConfirmPassword(e.target.value)}
                  className="input input-bordered w-full"
                />
              </label>

              <button
                className="btn btn-neutral w-full mt-6"
                onClick={handleUserInfo}
                type="button"
              >
                Confirm Changes
              </button>

              {/* Add logout button */}
              <button
                className="btn btn-outline btn-error w-full mt-2"
                onClick={handleLogout}
                type="button"
              >
                Logout
              </button>
            </form>
          </div>
        </div>
      </div>
    </div>
  )
}
