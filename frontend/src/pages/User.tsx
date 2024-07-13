import { PasswordChange } from "../components/User/PasswordChange";
import { Setting } from "../components/User/Setting";
import { UserInfo } from "../components/User/UserInfo";
export function User() {
  return (
    <>
      <div className="flex justify-center">
        <div className="grid-cols-2 -items-center lg:grid lg:w-3/4">
          <UserInfo />
          <PasswordChange />
          <Setting />
        </div>
      </div>
    </>
  );
}
