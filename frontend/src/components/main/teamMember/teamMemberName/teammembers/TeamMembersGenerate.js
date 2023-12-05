import React from "react";
import { useEffect, useState } from "react";

const TeamMembersGenerate = ({ names,hours,email}) => {
    const [isActive, setActive] = useState("false");

    const ToggleClass = () => {
      setActive(!isActive);
    };
  
    return (
        <div>
        <div class="accordion-wrap clients">
          <div className={isActive ? "item" : "item-open"} onClick={ToggleClass}>
            <div class="heading">
              <span key="{names}">{names}</span>
              <i>+</i>
            </div>
            <div
              className={isActive ? "details" : "detailss"}
              onClick={ToggleClass}
            >
              <ul class="form">
                <li>
                  <label>Client name:</label>
                  <input type="text" class="in-text" value={names} />
                </li>
                <li>
                  <label>hours:</label>
                  <input type="text" class="in-text" value={hours} />
                </li>
              </ul>
              <ul class="form">
                <li>
                  <label>email:</label>
                  <input type="text" class="in-text" value={email} />
                </li>
                
                <div class="inner">
                    <a href="javascript:;" class="btn green">
                    Save
                    </a>
                    <a href="javascript:;" class="btn red">
                    Delete
                    </a>
                </div>
                
              </ul>
              
              
            </div>
          </div>
        </div>
      </div>
    );
  };

export default TeamMembersGenerate
