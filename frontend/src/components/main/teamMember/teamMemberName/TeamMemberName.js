import React, { useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { getTeamMemberAsyn } from "../../../../redux/timsheetSlice";
import TeamMembersGenerate from "./teammembers/TeamMembersGenerate";


const TeamMemberName = () => {
    const dispatch = useDispatch();

    useEffect(() => {
      dispatch(getTeamMemberAsyn([]));
    }, [dispatch]);
  
    const members = useSelector((state) => state.timesheet);
  
  
    return (
      <div class="accordion-wrap clients">
        {members.map((member) => (
          <div key={member.id}>
            <TeamMembersGenerate
              names={member.name}
              hours={member.hours}
              email={member.email}
            
            />
          </div>
        ))}
      </div>
    );
  };

export default TeamMemberName
