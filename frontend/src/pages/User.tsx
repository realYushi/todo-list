import { PasswordChange } from "../components/PasswordChange";
import { Setting } from "../components/Setting";
import { UserInfo } from "../components/UserInfo";
export function User() {
    return (
        <>
            <UserInfo />
            <PasswordChange />
            <Setting />
        </>
    );
}
