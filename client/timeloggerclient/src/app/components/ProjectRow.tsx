import React from "react";
import { Project } from "../models/project.model";
import "../style.css";


interface IProjectsProps {
    project: Project,
    handleAddWork: (id: number) => void,
    handleSeeWork: (id: number) => void,
};

const ProjectRow: React.FC<IProjectsProps> = ({ project, handleAddWork, handleSeeWork }) => {
    return (
        <tr>
            <td className="border px-4 py-2 w-12">{project.id}</td>
            <td className="border px-4 py-2 w-12">{project.customerName}</td>
            <td className="border px-4 py-2">{project.name}</td>
            <td className="border px-4 py-2">{ project.status == 0? 'ACTIVE':(project.status == 1? 'CLOSED': 'CANCELLED')}</td>
            <td className="border px-4 py-2">{new Date(project.projectEndDate).toDateString()}</td>
            <td className="border px-4 py-2">
                <button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded" onClick={() => handleAddWork(project.id)}>
                Add Work
            </button>
                <button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded" onClick={() =>handleSeeWork(project.id)}>
                    See Work Report
            </button>
            </td>
        </tr>
    );
};

export default ProjectRow;

