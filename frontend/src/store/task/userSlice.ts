import { createSlice } from "@reduxjs/toolkit";
interface UserState {
  userId?: string; // Guid is represented as a string in TypeScript
  username: string;
  email: string;
  password: string;
  role: string;
  status: string;
  createdAt: string; // DateTime is typically represented as a string in JSON
  updatedAt?: string; // Optional field
}
const initialState: UserState = {
  username: "",
  email: "",
  password: "",
  role: "",
  status: "",
  createdAt: "",
  updatedAt: "",
};
const userSlice = createSlice({
  name: "user",
  initialState,
  reducers: {
    addUser() {},
    updateUser() {},
    deleteUser() {},
    readUsers() {},
  },
});
export default userSlice.reducer;
