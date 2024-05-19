import {Member} from "../../types/member.ts";
import React, {useState} from "react";
import {Link} from "react-router-dom";
// import {Problem, ValidationError} from "../../types/problem.ts";
import {AxiosError} from "axios";
import Problem from "../../types/problem.ts";

type Args = {
    member: Member,
    submitted: (member: Member) => void;
    error?: AxiosError<Problem>;
};


const MemberForm = ({member, submitted, error}: Args) => {
    const [memberState, setMemberState] = useState({...member})

    const onSubmit: React.MouseEventHandler<HTMLButtonElement> = async (e) => {
        e.preventDefault();
        submitted(memberState);
    };

    const errors = error?.response?.data.errors;

    return (
        <>
            <form>
                <div className="form-group mb-2">
                    <label htmlFor="firstName">First Name</label>
                    <input
                        type="text"
                        className="form-control"
                        placeholder="First Name"
                        value={memberState.firstName}
                        onChange={(e) =>
                            setMemberState({
                                ...memberState,
                                firstName: e.target.value,
                            })
                        }
                    />
                    {errors?.FirstName &&
                        <div className={"text-danger ms-2"}>
                            {errors.FirstName.join(', ')}
                        </div>
                    }
                </div>

                <div className="form-group mb-2">

                    <label htmlFor="lastName">Last Name</label>
                    <input
                        type="text"
                        className={"form-control"}
                        placeholder={"Last Name"}
                        value={memberState.lastName}
                        onChange={(e) => {
                            setMemberState({
                                ...memberState,
                                lastName: e.target.value
                            })
                        }}
                    />
                    {errors?.LastName &&
                        <div className={"text-danger ms-2"}>
                            {errors.LastName.join(', ')}
                        </div>
                    }
                </div>

                <div className="form-group mb-2">

                    <label htmlFor="ssr">Social security number</label>
                    <input
                        type="text"
                        className={"form-control"}
                        placeholder={"yyyymmdd-xxxx"}
                        value={memberState.ssr}
                        onChange={(e) => {
                            setMemberState({
                                ...memberState,
                                ssr: e.target.value
                            })
                        }}
                    />
                    {errors?.Ssr &&
                        <div className={"text-danger ms-2"}>
                            {errors.Ssr.join(', ')}
                        </div>
                    }
                </div>

                {/*<div className="form-group mb-2">*/}
                
                {/*    <label htmlFor="avatar">Avatar (link)</label>*/}
                {/*    <input*/}
                {/*        type="text"*/}
                {/*        className={"form-control"}*/}
                {/*        placeholder={"Link"}*/}
                {/*        value={memberState.avatar}*/}
                {/*        onChange={(e) => {*/}
                {/*            setMemberState({*/}
                {/*                ...memberState,*/}
                {/*                avatar: e.target.value*/}
                {/*            })*/}
                {/*        }}*/}
                {/*    />*/}
                {/*    {errors?.Avatar &&*/}
                {/*        <div className={"text-danger ms-2"}>*/}
                {/*            {errors.Avatar.join(', ')}*/}
                {/*        </div>*/}
                {/*    }*/}
                {/*</div>*/}

                <div className="form-group mb-2">

                    <label htmlFor="description">Description</label>
                    <input
                        type="text"
                        className={"form-control"}
                        placeholder={"Description"}
                        value={memberState.description}
                        onChange={(e) => {
                            setMemberState({
                                ...memberState,
                                description: e.target.value
                            })
                        }}
                    />
                    {errors?.Description &&
                        <div className={"text-danger ms-2"}>
                            {errors.Description.join(', ')}
                        </div>
                    }
                </div>
                
                <button
                    className={"btn btn-primary my-3"}
                    onClick={onSubmit}
                >
                    Submit
                </button>
                <Link
                    className={"btn btn-warning ms-2"}
                    to={"/members"}
                >
                    Back
                </Link>

            </form>
        </>
    );
}

export default MemberForm;


// console.log(error?.response?.data.errors);

// console.log(errors);
//
// console.log(errors?.FirstName ?? "this is undefined for some reason");
// console.log(errors?.firstName)

// console.log("Error object:", error);
// console.log("Validation Errors:", errors);
// if (error.response?.status !== 400) return <></>;
// const errors = error.response?.data.errors;


{/*<div className={"text-danger"}>Please fix the following:</div>*/
}
{/*{errors!.firstName && (<p>{errors!.toString()}</p>)}*/
}
{/*{errors!.firstName && <p className="text-danger">{errors!.firstName.join(", ")}</p>}*/
}
{/**/
}
{/*{Object.entries(errors!).map(([key, value]) => (*/
}
{/*    <ul key={key}>*/
}
{/*        <li>*/
}
{/*            {key}: {value.join(", ")}*/
}
{/*        </li>*/
}
{/*    </ul>*/
}
{/*))}*/
}


{/*{errors?.firstName && (*/
}
{/*    <div className="text-danger">*/
}
{/*        {errors.firstName.join(", ")}*/
}
{/*    </div>*/
}
{/*)}*/
}


{/*{error && error.response?.data.errors.firstName && (*/
}
{/*    <div className="text-danger">*/
}
{/*        {error.response.data.errors.firstName.join(", ")}*/
}
{/*    </div>*/
}
{/*)}*/
}
{/*{errors?.firstName && <div className="text-danger">{errors.firstName.join(", ")}</div>}*/
}


