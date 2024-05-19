import {useFetchMemberDetail, useUpdateMember} from "../../hooks/membersHooks.ts";
import MemberForm from "./MemberForm.tsx";
import {useParams} from "react-router";
import ApiStatus from "../api/ApiStatus.tsx";

// type Args = {
//     member: Member
// }

const MemberUpdate = () => {


    const  {id} = useParams();
    if (!id) throw Error("No member id provided");
    const memberId = parseInt(id);
    
    const { data: member, isSuccess, isLoading, isFetching, status } = useFetchMemberDetail(memberId);
    const updateMemberMutation = useUpdateMember();

    if (isLoading || isFetching) {
        return <ApiStatus status="loading" />;
    }

    if (!isSuccess || !member) {
        return <ApiStatus status={status} />;
    }


    return (
        <>


            <h1 className={"mb-4"}>Update member</h1>
            
            <div className="col-6">
                
                <MemberForm
                    member={member}
                    submitted={(member) => updateMemberMutation.mutate(member)}
                    error={updateMemberMutation.isError ? updateMemberMutation.error : undefined}
                ></MemberForm>
            </div>
        </>
    );




}



export default MemberUpdate; 