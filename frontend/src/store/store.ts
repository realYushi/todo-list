import { configureStore } from "@reduxjs/toolkit";
import taskreducers from "@store/task/taskSlice";
import listreducers from "@store/task/listSlice";
import userreducers from "@store/task/userSlice";

export const store = configureStore({
  reducer: {
    task: taskreducers,
    list: listreducers,
    user: userreducers,
  },
});
export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
