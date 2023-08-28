import React from "react";
import { Project } from "../models/project.model";
import ProjectRow from "./ProjectRow";
import { BASE_URL } from "../api/projects"
import "../style.css";


const addWork = async (id: number, duration: number) => {
    await fetch(`${BASE_URL}/projects/${id}/work`, {
        method: "POST",
        body: JSON.stringify({
            id: id,
            duration: duration
        }),
        headers: { 'Content-type': 'application/json; charset=UTF-8', },
    }).then((response) => response.json());
}

interface IListProjectsProps {
    projects: Project[],
    //trackings: Tracking[],
    setProjects: React.Dispatch<React.SetStateAction<Project[]>>
    //setTrackings: React.Dispatch<React.SetStateAction<Tracking[]>>
}

const ListProjects: React.FC<IListProjectsProps> = ({ projects }) => {

    const handleAddWork = (id: number) => {
        addWork(id, 8);
    };

    const handleSeeWork = (id: number) => { console.log(`work for ${id}`); };

    return (
        <>
            <div className="flex items-center my-6">
                <div className="w-1/2">

                </div>

                <div className="w-1/2 flex justify-end">

                </div>
            </div>



            <table className="table-fixed w-full">
                <thead className="bg-gray-200">
                    <tr>
                        <th className="border px-4 py-2 w-12">#</th>
                        <th className="border px-4 py-2">Customer</th>
                        <th className="border px-4 py-2">Project Name</th>
                        <th className="border px-4 py-2">Status</th>
                        <th className="border px-4 py-2">Project End Date</th>
                        <th className="border px-4 py-2">Action</th>
                    </tr>
                </thead>
                <tbody>
                    {projects.map(value => <ProjectRow key={value.id} project={value} handleAddWork={handleAddWork} handleSeeWork={handleSeeWork} />)}
                </tbody>
            </table>
        </>
    );
};

export default ListProjects;


