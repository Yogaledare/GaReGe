import {useFetchMembers} from "../../hooks/membersHooks.ts";
import ApiStatus from "../api/ApiStatus.tsx";
import {useNavigate} from "react-router";

const MembersTable = () => {
    const nav = useNavigate();
    const {data, status, isSuccess} = useFetchMembers();

    if (!isSuccess) {
        return (<ApiStatus status={status}/>)
    }

    return (
        <>
            <table className='table hover-pointer table-hover'>
                <thead>
                <tr>
                    <th scope={"col"}>ID</th>
                    <th scope={"col"}>First Name</th>
                    <th scope={"col"}>Last Name</th>
                    <th scope={"col"}>SSR</th>
                </tr>
                </thead>
                <tbody>
                {data &&
                    data.map((member) => (
                        <tr
                            key={member.memberId}
                            onClick={() => nav(`/members/${member.memberId}`)}
                        >
                            <td>{member.memberId}</td>
                            <td>{member.firstName}</td>
                            <td>{member.lastName}</td>
                            <td>{member.ssr}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </>
    );
};

export default MembersTable;
