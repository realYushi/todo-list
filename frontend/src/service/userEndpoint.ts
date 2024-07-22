import IUser from "@models/UserInterface"
import { baseApi } from "@service/baseApi"

export const userEndpoint = baseApi.injectEndpoints({
  endpoints: builder => ({
    getUser: builder.query<IUser, { userName: string; email: string }>({
      query: ({ userName, email }) => `user/${userName}/${email}`,
    }),
    register: builder.mutation<IUser, Partial<IUser>>({
      query: user => ({
        url: `auth/register`,
        method: "POST",
        body: user,
      }),
    }),
    login: builder.mutation<{ message: string; token: string }, Partial<IUser>>(
      {
        query: user => ({
          url: `auth/login`,
          method: "POST",
          body: user,
        }),
      },
    ),
    updateUser: builder.mutation<IUser, Partial<IUser>>({
      query: user => ({
        url: `user/${user.userId}`,
        method: "PUT",
        body: user,
      }),
    }),
  }),
  overrideExisting: false,
})

export const {
  useGetUserQuery,
  useRegisterMutation,
  useLoginMutation,
  useUpdateUserMutation,
} = userEndpoint
