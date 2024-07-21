import IList from "@modelsListInterface"
import { baseApi } from "@service/baseApi"

export const listEndpoint = baseApi.injectEndpoints({
  endpoints: builder => ({
    getLists: builder.query<IList[], void>({
      query: () => "list",
    }),
    getList: builder.query<IList, string>({
      query: listId => `list/${listId}`,
    }),
    addList: builder.mutation<IList, Partial<IList>>({
      query: list => ({
        url: `list`,
        method: "POST",
        body: list,
      }),
    }),
    updateList: builder.mutation<IList, Partial<IList>>({
      query: list => ({
        url: `list/${list.listId}`,
        method: "PUT",
        body: list,
      }),
    }),
    deleteList: builder.mutation<void, string>({
      query: listId => ({
        url: `list/${listId}`,
        method: "DELETE",
      }),
    }),
  }),
  overrideExisting: false,
})
export const {
  useGetListsQuery,
  useGetListQuery,
  useAddListMutation,
  useUpdateListMutation,
  useDeleteListMutation,
} = listEndpoint
