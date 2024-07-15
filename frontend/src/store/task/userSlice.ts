import { createSlice } from "@reduxjs/toolkit";
import IUser from "@models/UserInterface";
const initialState: IUser = {
  userId: "",
  username: "",
  email: "",
  password: "",
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
export const { addUser, updateUser, deleteUser, readUsers } = userSlice.actions;
