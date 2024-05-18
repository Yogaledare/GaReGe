type Error = {
    FirstName?: string[];
    LastName?: string[];
    Ssr?: string[];
    Avatar?: string[];
};


type Problem = {
    type: string;
    title: string;
    status: number;
    errors: Error;
};

export default Problem;


// type Error = {
//     [name: string]: string[];
// };


// type Error = {
//     [name in "firstName" | "lastName" | "ssr" | "avatar"]: string[];
// };

