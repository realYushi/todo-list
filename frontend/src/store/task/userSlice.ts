import { createSlice, PayloadAction } from "@reduxjs/toolkit";
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
    updateUser(state, action: PayloadAction<IUser>) {
      state.email = action.payload.email;
      state.password = action.payload.password;
    },
  },
});
export default userSlice.reducer;
export const { addUser, updateUser } = userSlice.actions;
