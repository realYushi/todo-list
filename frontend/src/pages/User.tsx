import { PasswordChange } from "../components/User/PasswordChange";
import { Setting } from "../components/User/Setting";
import { UserInfo } from "../components/User/UserInfo";
export function User() {
  return (
    <>
      <UserInfo />
      <PasswordChange />
      <Setting />
    </>
  );
}
