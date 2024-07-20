import { UserInfo } from "@pages/User/UserInfo";
export function User() {
  return (
    <>
      <div className="flex justify-center">
        <div className="grid-cols-2 -items-center lg:grid lg:w-3/4">
          <UserInfo />
        </div>
      </div>
    </>
  );
}
