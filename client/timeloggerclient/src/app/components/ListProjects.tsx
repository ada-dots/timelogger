import React from "react";
import { Project } from "../models/project.model"

interface IListProjectsProps {
    projects: Project[]
}

const ListProjects: React.FC<IListProjectsProps> = ({ projects }) => {
    return (
        <table className="table-fixed w-full">
            <thead className="bg-gray-200">
                <tr>
                    <th className="border px-4 py-2 w-12">#</th>
                    <th className="border px-4 py-2 w-12">Customer</th>
                    <th className="border px-4 py-2">Project Name</th>
                </tr>
            </thead>
            <tbody>
                {projects.map(value =>
                    <tr>

                        <td className="border px-4 py-2 w-12">{value.id}</td>
                        <td className="border px-4 py-2 w-12">{value.customerName}</td>
                        <td className="border px-4 py-2">{value.name}</td>
                    </tr>
                )}
            </tbody>
        </table>
    );
};

export default ListProjects;