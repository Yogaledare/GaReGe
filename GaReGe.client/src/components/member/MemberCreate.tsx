import MemberForm from "./MemberForm.tsx";
import {useAddMember} from "../../hooks/membersHooks.ts";
import {Member} from "../../types/member.ts";


const MemberCreate = () => {

    const addMemberMutation = useAddMember();

    const member: Member = {
        firstName: "",
        lastName: "",
        ssr: "",
        avatar: "",
        description: "",
    }


    return (
        <>


            <h1 className={"mb-4"}>Register new member</h1>

            <div className="col-6">

                <MemberForm
                    member={member}
                    submitted={(member) => addMemberMutation.mutate(member)}
                    error={addMemberMutation.isError ? addMemberMutation.error : undefined}
                ></MemberForm>
            </div>
        </>
    );

}


export default MemberCreate; 
