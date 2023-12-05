import React from "react";
import { useEffect, useState } from "react";

const Person = ({ names, zip, address, country, city }) => {
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
                <label>Zip/Postal code:</label>
                <input type="text" class="in-text" value={names} />
              </li>
            </ul>
            <ul class="form">
              <li>
                <label>Address:</label>
                <input type="text" class="in-text" value={address} />
              </li>
              <li>
                <label>Country:</label>
                <input type="text" class="in-text" value={country} />
              </li>
            </ul>
            <ul class="form last">
              <li>
                <label>City:</label>
                <input type="text" class="in-text" value={city} />
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

export default Person;
