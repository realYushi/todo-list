import { useState, FormEvent } from "react"
import { useNavigate } from "react-router-dom"
import { useLoginMutation, useRegisterMutation } from "@serviceuserEndpoint"
import IUser from "@modelsUserInterface"

export function FormComponent() {
  return (
    <div className="hero min-h-screen bg-base-200">
      <div className="hero-content w-full flex-col bg-neutral shadow-lg lg:flex-row">
        <RegisterForm />
        <LoginForm />
      </div>
    </div>
  )
}

const RegisterForm = () => {
  const [userName, setUserName] = useState("")
  const [password, setPassword] = useState("")
  const [email, setEmail] = useState("")
  const [register, { isLoading, isError, error }] = useRegisterMutation()
  const [successMessage, setSuccessMessage] = useState("")

  const handleRegister = async (e: FormEvent) => {
    e.preventDefault()
    setSuccessMessage("")

    if (password.length < 8) {
      alert("Password must be at least 8 characters long")
      return
    }
    const user: Partial<IUser> = {
      username: userName,
      email: email,
      password: password,
    }

    try {
      await register(user).unwrap()
      setSuccessMessage("User registered successfully!")
      // Clear form fields
      setUserName("")
      setPassword("")
      setEmail("")
    } catch (err) {
      console.error("Failed to register:", err)
    }
  }

  return (
    <div className="w-10/12 lg:w-1/2 lg:flex-col">
      <div className="text-center">
        <h1 className="m-4 text-5xl font-bold">Register</h1>
      </div>
      <div className="card w-full bg-base-100 shadow-sm">
        <form className="card-body" onSubmit={handleRegister}>
          <div className="form-control">
            <label className="label" htmlFor="registerUsername">
              <span className="label-text">User Name</span>
            </label>
            <input
              id="registerUsername"
              type="text"
              onChange={e => setUserName(e.target.value)}
              placeholder="user name"
              className="input input-bordered"
              required
            />
          </div>
          <div className="form-control">
            <label className="label" htmlFor="registerEmail">
              <span className="label-text">Email</span>
            </label>
            <input
              id="registerEmail"
              type="email"
              placeholder="email"
              className="input input-bordered"
              onChange={e => setEmail(e.target.value)}
              required
            />
          </div>
          <div className="form-control">
            <label className="label" htmlFor="registerPassword">
              <span className="label-text">Password</span>
            </label>
            <input
              id="registerPassword"
              type="password"
              placeholder="password"
              className="input input-bordered"
              onChange={e => setPassword(e.target.value)}
              required
            />
          </div>
          <div className="form-control mt-6 gap-2">
            <button
              type="submit"
              className="btn btn-primary"
              disabled={isLoading}
            >
              {isLoading ? "Registering..." : "Register"}
            </button>
          </div>
          {isError && <p className="text-error">{"An error occurred"}</p>}
          {successMessage && <p className="text-success">{successMessage}</p>}
        </form>
      </div>
    </div>
  )
}

const LoginForm = () => {
  const [userName, setUserName] = useState("")
  const [password, setPassword] = useState("")
  const [email, setEmail] = useState("")
  const [login, { isLoading, isError, error }] = useLoginMutation()
  const navigate = useNavigate()

  const handleLogin = async (e: FormEvent) => {
    e.preventDefault()
    const user: Partial<IUser> = {
      username: userName,
      email: email,
      password: password,
    }

    try {
      await login(user).unwrap()
      navigate("/dashboard")
    } catch (err) {
      console.error("Failed to login:", err)
    }
  }

  return (
    <div className="w-10/12 lg:w-1/2 lg:flex-col">
      <div className="text-center">
        <h1 className="m-4 text-5xl font-bold">Login</h1>
      </div>
      <div className="card w-full bg-base-100 shadow-sm">
        <form className="card-body" onSubmit={handleLogin}>
          <div className="form-control">
            <label className="label" htmlFor="loginUsername">
              <span className="label-text">User Name</span>
            </label>
            <input
              id="loginUsername"
              type="text"
              placeholder="user name"
              className="input input-bordered"
              onChange={e => setUserName(e.target.value)}
              required
            />
          </div>
          <div className="form-control">
            <label className="label" htmlFor="loginEmail">
              <span className="label-text">Email</span>
            </label>
            <input
              id="loginEmail"
              type="email"
              placeholder="email"
              className="input input-bordered"
              onChange={e => setEmail(e.target.value)}
              required
            />
          </div>
          <div className="form-control">
            <label className="label" htmlFor="loginPassword">
              <span className="label-text">Password</span>
            </label>
            <input
              id="loginPassword"
              type="password"
              placeholder="password"
              className="input input-bordered"
              onChange={e => setPassword(e.target.value)}
              required
            />
          </div>
          <div className="form-control mt-6 gap-2">
            <button
              type="submit"
              className="btn btn-primary"
              disabled={isLoading}
            >
              {isLoading ? "Logging in..." : "Login"}
            </button>
          </div>
          {isError && <p className="text-error">{"An error occurred"}</p>}
        </form>
      </div>
    </div>
  )
}
