import { useState } from 'react';
import type { Project } from '../types/Project';

function ProjectList() {

    const [ projects, setProjects ] = useState<Project[]>([]);

    return (
        <>
            <h1>Water Projects</h1>
            <br />
            {projects.map((project) => (
                <div id="projectCard" key={project.projectId}>
                    <h2>{project.projectName}</h2>
                    <p>Type: {project.projectType}</p>
                    <p>Regional Program: {project.projectRegionalProgram}</p>
                    <p>Impact: {project.projectImpact}</p>
                    <p>Phase: {project.projectPhase}</p>
                    <p>Functionality Status: {project.projectFunctionalityStatus}</p>
                </div>
            ))}
        </>
    );
}

export default ProjectList;