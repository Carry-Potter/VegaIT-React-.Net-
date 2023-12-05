import React from "react";
import { useEffect, useState } from "react";


const Projets = ({ names, description, client, teamMember }) => {
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
                  <label>Project name:</label>
                  <input type="text" class="in-text" value={names} />
                </li>
                <li>
                  <label>description:</label>
                  <input type="text" class="in-text" value={description} />
                </li>
              </ul>
              <ul class="form">
                <li>
                  <label>client</label>
                  <input type="text" class="in-text" value={client} />
                </li>
                <li>
                  <label>teamMember:</label>
                  <input type="text" class="in-text" value={teamMember} />
                </li>
              </ul>
             
              
              <div class="buttons">
                <div class="inner">
                  <a href="javascript:;" class="btn green">
                    Save
                  </a>
                  <a href="javascript:;" class="btn red">
                    Delete
                  </a>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    );
};


export default Projets
