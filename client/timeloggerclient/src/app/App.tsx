import React, { useState, useEffect } from "react";
import Projects from "./views/Projects";
import { Project } from "./models/project.model"
import Example from "./views/Example";
import getAll, { BASE_URL } from "./api/projects"
import "./style.css";


/*type post = {
    id: string;
    title: string;
    body: string;
};*/

//type Project = {
//    Name: string;
//    CustomerName: string;
//    UserName: string;
//    status: number;
//    ProjectStartDate: Date;
//    ProjectEndDate: Date;
//    Tasks: number
//}

export default function App() {

    //const [posts, setPosts] = useState<post[]>([]);

    //const [result, setResult] = useState<Project[]>([]);

    //useEffect(() => {
    //    const jsonData = await getAll();
    //    setResult(jsonData);

    //},[]);

    /* useEffect(() => {
         fetch('https://jsonplaceholder.typicode.com/posts?_limit=10')
             .then((response) => response.json())
             .then((data) => {
                 console.log(data);
                 setPosts(data);
             })
             .catch((err) => {
                 console.log(err.message);
             });
     }, []);
     
 
         <div className="container mx-auto">
                     <div className="posts-container">
                         {posts.map((post) => {
                             return (
                                 <div className="post-card" key={post.id}>
                                     <h2 className="post-title">{post.title}</h2>
                                     <p className="post-body">{post.body}</p>
                                     <div className="button">
                                         <div className="delete-btn">Delete</div>
                                     </div>
                                 </div>
                             );
                         })}
                     </div>
                 </div>
 
     */

    const [projects, setProjects] = useState<Project[]>([]);

    useEffect(() => {
        fetch(`${BASE_URL}/projects`)
            .then(response => response.json())
            .then(data => setProjects(data))
            .catch(err => console.log(err));
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
                    <Projects />
                </div>

                <div className="container mx-auto">
                    <Example />
                </div>
            </main>
        </>
    );
}
