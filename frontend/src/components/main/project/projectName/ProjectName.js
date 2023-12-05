import React, { useEffect } from 'react'
import { useSelector, useDispatch } from "react-redux";
import { getProjectAsyn } from '../../../../redux/timsheetSlice';
import Projets from './projects/Projets';

const ProjectName = () => {
    const dispatch = useDispatch();

    useEffect(() => {
      dispatch(getProjectAsyn([]));
    }, [dispatch]);
  
    const projects = useSelector((state) => state.timesheet);
  
  
    return (
      <div class="accordion-wrap clients">
        {projects.map((project) => (
          <div key={project.id}>
            <Projets
              names={project.name}
              description={project.description}
              client={project.client}
              teamMember={project.teamMember}
            />
          </div>
        ))}
      </div>
    );
  };

export default ProjectName
