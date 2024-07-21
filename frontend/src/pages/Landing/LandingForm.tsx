import IUser from "@modelsUserInterface"
import { useLoginMutation, useRegisterMutation } from "@serviceuserEndpoint"
import { useState } from "react"

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
  const [register] = useRegisterMutation()
  const [login] = useLoginMutation()

  const handleLogin = () => {
    const user: IUser = {
      userId: "",
      username: userName,
      email: email,
      password: password,
    }
    login(user)
  }
  return (
    <div className="w-10/12 lg:w-1/2 lg:flex-col">
      <div className="text-center">
        <h1 className="m-4 text-5xl font-bold">Register</h1>
      </div>
      <div className="card w-full bg-base-100 shadow-sm">
        <form className="card-body">
          <div className="form-control">
            <label className="label" id="registerForm">
              <span className="label-text">User Name</span>
            </label>
            <input
              type="text"
              onChange={e => setUserName(e.target.value)}
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
              onChange={e => setEmail(e.target.value)}
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
              onChange={e => setPassword(e.target.value)}
              required
            />
            <label className="label">
              <a href="#" className="link-hover link label-text-alt"></a>
            </label>
          </div>
          <div className="form-control mt-6 gap-2">
            <button className="btn btn-primary " onClick={handleLogin}>
              Register
            </button>
          </div>
        </form>
      </div>
    </div>
  )
}
const LoginForm = () => {
  const [userName, setUserName] = useState("")
  const [password, setPassword] = useState("")
  const [email, setEmail] = useState("")
  const [register] = useRegisterMutation()
  const [login] = useLoginMutation()
  const handleRegister = () => {
    const user: IUser = {
      userId: "",
      username: userName,
      email: email,
      password: password,
    }
    register(user)
  }
  return (
    <div className="w-10/12 lg:w-1/2 lg:flex-col">
      <div className="text-center">
        <h1 className="m-4 text-5xl font-bold">Login</h1>
      </div>
      <div className="card w-full bg-base-100 shadow-sm">
        <form className="card-body">
          <div className="form-control">
            <label className="label" id="loginForm">
              <span className="label-text">User Name</span>
            </label>
            <input
              type="text"
              placeholder="user name"
              className="input input-bordered"
              onChange={e => setUserName(e.target.value)}
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
              onChange={e => setPassword(e.target.value)}
              required
            />
            <label className="label">
              <a href="#" className="link-hover link label-text-alt"></a>
            </label>
          </div>
          <div className="form-control mt-6 gap-2">
            <button className="btn btn-primary" onClick={handleRegister}>
              Login
            </button>
          </div>
        </form>
      </div>
    </div>
  )
}
