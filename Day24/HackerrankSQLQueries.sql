-- 1. https://www.hackerrank.com/challenges/more-than-75-marks/problem?isFullScreen=true
select Name from students where Marks > 75 order by right(Name, 3), ID

-- 2. https://www.hackerrank.com/challenges/contest-leaderboard/problem
with CTE (hacker_id, max_score) as
(select hacker_id, max(score) from submissions group by hacker_id, challenge_id)
select CTE.hacker_id, h.name, sum(max_score) from CTE join hackers h on h.hacker_id = CTE.hacker_id group by CTE.hacker_id, h.name having sum(max_score) != 0 order by sum(max_score) desc, CTE.hacker_id;

select h.hacker_id, h.name, sum(max_score) from 
(select hacker_id, max(score) as max_score from Submissions group by hacker_id, challenge_id) t join hackers h on h.hacker_id = t.hacker_id group by h.hacker_id, h.name having sum(max_score) > 0 order by sum(max_score) desc, h.hacker_id;