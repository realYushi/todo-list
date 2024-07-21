import {
  createApi,
  fetchBaseQuery,
  setupListeners,
} from "@reduxjs/toolkit/query/react"
import { store } from "@store/store"
export const baseApi = createApi({
  reducerPath: "baseApi",
  baseQuery: fetchBaseQuery({ baseUrl: "https://localhost:5001/api/" }),
  endpoints: () => ({}),
})
setupListeners(store.dispatch)
