import React, { useEffect, useState } from "react";
import { BASE_URL } from "./api/projects"
import { Project } from "./models/project.model";
import ListProjects from "./components/ListProjects";
import "./style.css";

export default function App() {


    const [projects, setProjects] = useState<Project[]>([]);


    useEffect(() => {
        fetch(`${BASE_URL}/projects`)
            .then(response => response.json())
            .then(data => setProjects(data))
            .catch(err => console.log(err));
        var newArray = projects.sort((a, b) => b.projectEndDate.getTime() - a.projectEndDate.getTime());
        setProjects(newArray);
    }, []);

    return (
        <>
            <header className="bg-gray-900 text-white flex items-center h-12 w-full">
                <div className="container mx-auto">
                    <a className="navbar-brand" href="/">
                        Timelogger
                    </a>
                </div>
            </header>

            <main>
                <div className="container mx-auto">
                    <ListProjects projects={projects} setProjects={setProjects} />
                </div>

            </main>
        </>
    );
}
