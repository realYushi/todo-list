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
    register(state, action: PayloadAction<IUser>) {},
    updateUser(state, action: PayloadAction<IUser>) {
      state.email = action.payload.email;
      state.password = action.payload.password;
    },
    login(state, action: PayloadAction<IUser>) {},
  },
});
export default userSlice.reducer;
export const { login, register, updateUser } = userSlice.actions;
