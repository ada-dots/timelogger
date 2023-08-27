import React, { useState } from "react";
import ListProjects from "../components/ListProjects";
import Table from "../components/Table";
import { Project } from "../models/project.model";


export default function Projects() {
    const [projects, setProjects] = useState<Project[]>([]);

    return (
        <>
            <div className="flex items-center my-6">
                <div className="w-1/2">
                    <button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">
                        Add entry
                    </button>
                </div>

                <div className="w-1/2 flex justify-end">
                    <form>
                        <input
                            className="border rounded-full py-2 px-4"
                            type="search"
                            placeholder="Search"
                            aria-label="Search"
                        />
                        <button
                            className="bg-blue-500 hover:bg-blue-700 text-white rounded-full py-2 px-4 ml-2"
                            type="submit"
                        >
                            Search
                        </button>
                    </form>
                </div>
            </div>

            <Table />

            <ListProjects />
        </>
    );
}
