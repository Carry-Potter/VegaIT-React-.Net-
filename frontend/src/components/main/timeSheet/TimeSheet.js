import React from "react";
import Day from "../days/Day";
import Calendar from "react-calendar";

const TimeSheet = () => {
  return (
    <div class="container">
      <div class="wrapper">
        <section class="content">
          <h2>
            <i class="ico timesheet"></i>TimeSheet
          </h2>
          <div class="grey-box-wrap">
            <div class="top">
              <a href="javascript:;" class="prev">
                <i class="zmdi zmdi-chevron-left"></i>previous month
              </a>
              <span class="center">February, 2013</span>
              <a href="javascript:;" class="next">
                next month<i class="zmdi zmdi-chevron-right"></i>
              </a>
            </div>
            <div class="bottom"></div>
          </div>
          <table class="month-table">
            <tr class="head">
              <th>
                <span>monday</span>
              </th>
              <th>tuesday</th>
              <th>wednesday</th>
              <th>thursday</th>
              <th>friday</th>
              <th>saturday</th>
              <th>sunday</th>
            </tr>
            <tr class="mobile-head">
              <th>mon</th>
              <th>tue</th>
              <th>wed</th>
              <th>thu</th>
              <th>fri</th>
              <th>sat</th>
              <th>sun</th>
            </tr>
            {Array.from(Array(5), (e, i) => {
              return (
                <tr>
                  {Array.from(Array(7), (e, i) => {
                    return <Day hours={2} day={2} />;
                  })}
                </tr>
              );
            })}
          </table>
          <div class="total">
            <span>
              Total hours: <em>90</em>
            </span>
          </div>
        </section>
      </div>
    </div>
  );
};

export default TimeSheet;
